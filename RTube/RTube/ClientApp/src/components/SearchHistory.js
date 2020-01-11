import React, { Component } from 'react';
import {YouTubeList} from './YouTubeList'

export class SearchHistory extends Component {

    constructor(props) {
        super(props);
        this.state = { items: [], loading: true };
    }

    componentDidMount() {
        this.fetchHistory();
    }

    static renderItems(items) {
        return <YouTubeList items={items} />
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SearchHistory.renderItems(this.state.items);

        return (
            <div>
                <h1 id="tabelLabel" >Search history</h1>
                {contents}
            </div>
        );
    }

    async fetchHistory() {
        const response = await fetch('searchhistory');
        const data = await response.json();
        this.setState({ items: data, loading: false });
    }

}

