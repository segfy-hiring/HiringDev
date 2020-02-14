import React from 'react';
import { Button, Form, FormControl, InputGroup, Navbar } from "react-bootstrap";
import './App.css';
import SearchResults from './SearchResults';

class App extends React.Component {
  constructor() {
    super()
    this.state = {
      query: "",
      isLoading: false,
      results: []
    }
    this.handleChange = this.handleChange.bind(this)
    this.handleSubmit = this.handleSubmit.bind(this)
  }

  handleChange(event) {
    const { name, value } = event.target
    this.setState({[name]: value})
  }

  handleSubmit(event) {
    event.preventDefault()

    this.setState({isLoading: true})

    fetch(`https://j60slmyuff.execute-api.us-east-1.amazonaws.com/dev/search?q=${encodeURIComponent(this.state.query)}`)
      .then(response => response.json())
      .then(data => this.setState({isLoading: false, results: data}))
  }

  render() {
    return (
      <div className="App container">
        <Navbar className="bg-light justify-content-between">
          <Navbar.Brand>Youtube search test</Navbar.Brand>
          <Form inline>
            <InputGroup>
              <FormControl name="query" value={this.state.query} onChange={this.handleChange} />
              <InputGroup.Append>
                <Button variant="outline-secondary" onClick={this.handleSubmit}>Search</Button>
              </InputGroup.Append>
            </InputGroup>
          </Form>
        </Navbar>
        <div className="mx-auto" style={{maxWidth: '894px'}}>
          <SearchResults isLoading={this.state.isLoading} results={this.state.results}/>
        </div>

      </div>
    )
  }
}

export default App;
