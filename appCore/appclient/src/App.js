import React from 'react';
import './App.css';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import YoutubeList from './components/YoutubeList';

function App() {
  //console.log(process.env.REACT_APP_URLBASE);
  return (
    <div className="container mt-5">
        {/* <img src={logo} className="App-logo" alt="logo" /> */}
        <div className="row">
        <InputGroup className="mb-3">
          <FormControl
            placeholder="Search on Youtube"
            aria-label="Search on Youtube"
            aria-describedby="basic-addon2"
          />
          <InputGroup.Append>
            <Button variant="outline-secondary">Go!</Button>
          </InputGroup.Append>
        </InputGroup>
        </div>
        
        <div className="row">
          <YoutubeList />
        </div>
    </div>
  );
}

export default App;
