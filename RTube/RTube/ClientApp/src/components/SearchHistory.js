import React, { Component } from 'react';
import { YouTubeList } from './YouTubeList'

export class SearchHistory extends Component {

    constructor(props) {
        super(props);
        this.state = { items: [], prevPage: '', nextPage: '', loading: true };
        this.fetchHistory = this.fetchHistory.bind(this);
        this.renderItems = this.renderItems.bind(this);
    }

    componentDidMount() {
        this.fetchHistory('searchhistory');
    }

    renderItems(state) {
        return (<div>
            <YouTubeList items={state.items} />
            <div>
                <button disabled={state.prevPage == ''} onClick={() => this.fetchHistory(state.prevPage)}>Previous</button>
                <button disabled={state.nextPage == ''} onClick={() => this.fetchHistory(state.nextPage)}>Next</button>
            </div>
        </div>);
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderItems(this.state);

        return (
            <div>
                <h1 id="tabelLabel" >Search history</h1>
                {contents}
            </div>
        );
    }

    async fetchHistory(url) {
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ items: data.result, prevPage: data.prevPage, nextPage: data.nextPage, loading: false });
    }

}

