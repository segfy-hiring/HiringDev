import React, {useState, useEffect} from 'react'
import './App.css';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import YoutubeList from './components/YoutubeList';
import Loading from './components/Partials/Loading';
import axios from 'axios';



const App = (props) => {
  const [isLoading, setIsLoading] = useState(false)
  const [YTList, setYTList] = useState([])
  const [hasError, setErrors] =  useState(false)


 
  
  useEffect(() => {
    async function fetchData() {
      const res = await fetch("/Youtube");
      res.json()
        .then(res => setYTList(res))
        .catch(err => setErrors(err));
    }

    fetchData();
    
  },[]);
  //console.log(YTList);

  
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
          {isLoading &&
            <Loading label="Aguarde....Carregando lista" icon={true} />
          }

          {!isLoading &&
                    <YoutubeList items={YTList} />
          }
        </div>
    </div>
  );
}

export default App;
