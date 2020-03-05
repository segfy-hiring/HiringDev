import React from 'react';

const YoutubeList = (props) => {
    //console.log(props.items)
    return (
        props.items ?
        <ul>
            {props.items.map(item =>
                <div className="col-md-3" key={item._id}>
                <h2>{item.title}</h2>
                </div>
            )}
        </ul>
        : <div></div>
    );
}

export default YoutubeList;