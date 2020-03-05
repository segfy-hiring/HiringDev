import React from 'react';

const YoutubeList = (props) => {
    //console.log(props.items)
    return (
        props.items ?
        <ul>
            {props.items.map(item =>
                <li key={item._id}>{item.title}</li>
            )}
            
        </ul>
        : <div></div>
    );
}

export default YoutubeList;