import React, { Component } from 'react';
import { YouTubeList } from './YouTubeList'

export class Search extends Component {

    constructor(props) {
        super(props);
        this.state = { youTubeResult: null, loading: false, query: null, errorMessage: null };

        this.performSearch = this.performSearch.bind(this);
        this.search = this.search.bind(this);
        this.renderSearchResult = this.renderSearchResult.bind(this);
    }

    renderSearchResult(youTubeResult) {

        return (<div>
            {youTubeResult ?


                <div>
                    <YouTubeList items={youTubeResult.items} />
                    <div>
                        <button disabled={youTubeResult.prevPageToken == null} onClick={() => this.performSearch(youTubeResult.prevPageToken)}>Previous</button>
                        <button disabled={youTubeResult.nextPageToken == null} onClick={() => this.performSearch(youTubeResult.nextPageToken)}>Next</button>
                    </div>
                </div> : <div></div>

            }

        </div>);

    }

    handleInputChange = () => {
        this.setState({
            query: this.searchField.value
        })
    }

    handleKeyDown = (e) => {
        if (e.key === 'Enter') {
            this.performSearch();
        }
    }

    search(query, pageToken) {

        var url = `youtube?query=${query}`;

        if (pageToken) {
            url = `${url}&pageToken=${pageToken}`;
        }

        fetch(url)
            .then(response => response.json())
            .catch(error => {
                this.setState({
                    errorMessage: 'Cannot retrieve api data, probably we exceeded quota',
                    loading: false
                });
            })
            .then(json => {
                this.setState({ youTubeResult: json, loading: false });
            });

    }

    performSearch(nextOrPrevPageToken) {


        this.setState({ loading: true, errorMessage: null });

        let pageToken = null;

        if (nextOrPrevPageToken) {
            pageToken = nextOrPrevPageToken
        }

        this.search(this.state.query, pageToken);
    }

    render() {

        let contents = this.state.errorMessage ?
            <p><em>{this.state.errorMessage}</em></p>

            :

            this.state.loading ? 
            <p><em>Loading...</em></p>
            : this.renderSearchResult(this.state.youTubeResult);

        return (
            <div>
                <div className="row">
                    <div className="col">
                        <input
                            placeholder="Search for..."
                            className="form-control"
                            type="search"
                            ref={input => this.searchField = input}
                            onChange={this.handleInputChange}
                            onKeyDown={this.handleKeyDown}
                        />
                    </div>
                    <div className="col">
                        <button className="btn" onClick={() => this.performSearch()}>Search</button>
                    </div>
                </div>

                {contents}

            </div>

        );
    }




}

