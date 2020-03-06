import React from 'react';
import Moment from 'moment';




const YoutubeList = (props) => {
    
    return (
        props.items ?
        <>
        <h2 className="text-center border-bottom mb-4">Search for: {props.term}</h2>
        <ul>
            {props.items.map(item =>
                <div className="row m-2" key={item._id}>
                    <div className="col-md-4">
                        <img src={item.thumbnail} className="img img-thumbnail" alt={item.title} />
                    </div>

                    <div className="col-md-8">
                        <h4>Title: {item.title}</h4>
                        <p>Description: {item.description}</p>
                        <p>Published: {Moment(item.publishedAt).format("DD/MM/YYYY")}</p>
                    </div>
                
                </div>
            )}
        </ul>
        </>
        : <div></div>
    );
}

export default YoutubeList;