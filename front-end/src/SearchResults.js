import React from 'react'
import { Card } from 'react-bootstrap'

function SearchResults(props) {
    const haveResults = props.results.length > 0

    return (
        props.isLoading ?
            <div>Loading...</div> :
            <div style={{display: 'flex', flexWrap: 'wrap' }}>{
                haveResults ?
                    (
                        props.results.map(item =>
                            <Card style={{ width: '18rem', margin: "5px" }}>
                                <Card.Img variant="top" src={item.thumbnails.default.url} />
                                <Card.Body>
                                    <Card.Title>{item.title}</Card.Title>
                                    <Card.Text>{item.description}</Card.Text>
                                </Card.Body>
                            </Card>)
                    ) :
                    null
            }</div>
    )
}

export default SearchResults