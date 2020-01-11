import React from 'react';

export function YouTubeList(props) {
    return (
        props.items ?
            <ul>

                {props.items.map(item =>
                    <div className="card" key={item.id} style={{ marginBotton: '1em' }}>
                        <div className="row no-gutters">
                            <div className="col-md-4">
                                <img src={item.thumbnail} className="card-img" alt="..." />
                            </div>

                            <div className="col-md-8">
                                <div className="card-body">
                                    <h5 className="card-title">{item.title}</h5>
                                    <p className="card-text">{item.description}</p>
                                    <p className="card-text"><small className="text-muted">{item.publishedAt}</small></p>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </ul>
            : <div></div>
    );
}