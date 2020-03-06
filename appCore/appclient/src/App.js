import React, {useState, useEffect} from 'react'
import './App.css';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
import Button from 'react-bootstrap/Button';
import YoutubeList from './components/YoutubeList';
import Loading from './components/Partials/Loading';



const App = (props) => {
  const [isLoading, setIsLoading] = useState(false)
  const [YTList, setYTList] = useState([])
  const [searchTerm, setSearchTerm] = useState("")
  const [title, setTitle] = useState("")

  const handleSubmit = (evt) => {
    evt.preventDefault();
    setIsLoading(true);
    fetchData(searchTerm);
    setTitle(searchTerm);
}
  async function fetchData(query) {
    const res = await fetch("/api/Youtube/"+query);
    res.json()
      .then(res => setYTList(res),  setIsLoading(false))
      .catch(err => console.log(err));
  }
  
  
  return (
    <div className="container mt-5">
        <div className="row">
        <form className="w-100" onSubmit={handleSubmit}>
        <InputGroup className="mb-3">
          <FormControl
            placeholder="Search on Youtube"
            aria-label="Search on Youtube"
            aria-describedby="basic-addon2"
            value={searchTerm}
            onChange={e => setSearchTerm(e.target.value)}
          />
          <InputGroup.Append>
            <Button type="submit" variant="outline-secondary">Go!</Button>
          </InputGroup.Append>
        </InputGroup>
        </form>
        </div>
        
          
          {isLoading &&
            <Loading label="Loading, please wait ;)" icon={true} />
          }

          {!isLoading &&
                    <YoutubeList items={YTList.items} term={title} />
          }
    </div>
  );
}

export default App;
