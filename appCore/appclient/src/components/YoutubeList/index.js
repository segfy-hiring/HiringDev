import React from 'react';

export function YoutubeList(props) {
    return (
        props.items ?
        <ul>
            <li></li>
        </ul>
        : <div></div>
    );
}