import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import axios from 'axios';

function AddMovie(props) {
   const [movies, setMovies] = useState([]);
  const [Title, setTitle] = useState('')
    const [ImgUrl, setImgUrl] = useState('')
    const [CategoryId, setCategoryId] = useState(0)
   const [Rate, setRate] = useState(0)


useEffect(()=> {
    const GetMovies = () => {
        axios.get('https://localhost:44374/api/Movies/ReadMovie')
        .then((result)=>{
             console.log(result.data.readMovieData) 
             const allMovies = result.data.readMovieData
            setMovies(allMovies)

        })
    } 
    GetMovies();
 }, [])

 function movieExists(Title) {
  return movies.some(function(el) {
    return el.Title === Title;
  }); 
}


    const DeleteMovie = () => {
        axios.delete('https://localhost:44374/api/Movies/DeleteMovie')
        .then((result) => {
            alert("Deleted")
        })
        .catch((error)=> {
            alert(error)
        })
    }

    const addNewMovie = (e) => {
       if(movieExists(Title)){
            alert('The Movie exist!')
       }else {
         if(validateForm()) {
       e.preventDefault();
       const data = {Title: Title, ImgUrl: ImgUrl, CategoryId: CategoryId, Rate: Rate}
       axios.post('https://localhost:44374/api/Movies/CreateMovie', data)
       .then((result)=>
       {
           setMovies(result.data)
           console.log(result.data)
           DeleteMovie()

       })
    }
  }
    }

    const useStyles = makeStyles((theme) => ({
        margin: {
          margin: theme.spacing(1),
        },
        extendedIcon: {
          marginRight: theme.spacing(1),
        },
      }));
    
      const classes = useStyles();
    
      function closeModal() {

      }
    
  
      const validateForm = () => {

        let ok = true;

        if (Title == '') {
            ok = false;
            alert("Please fill a Title");
        }

        if (ImgUrl == '') {
            ok = false;
            alert("Please fill a Image Url");
        }

        if (CategoryId == 0) {
            ok = false;
            alert("Please fill a CategoryId");
        }

        if(Rate == 0) {
            ok = false;
            alert("Please fill a Rate");
        }

        return ok;
    }


    return (
        <div id="modal_bg">
      <form className={classes.root} noValidate autoComplete="off">
        <div id="form_bg">
          <span id="close" onClick={closeModal}>
            {" "}
            X{" "}
          </span>
          <h2 className="form_header">New Movie:</h2>
          <TextField
            type="text"
            label="Title"
            id="Title"
            value={Title}
            onChange={(e) => setTitle(e.target.value)}
          />

          <br />
          <TextField
            type="text"
            label="ImgUrl"
            id="ImgUrl"
            value={ImgUrl}
            onChange={(e) => setImgUrl(e.target.value)}
          />
          <br />
          <TextField
            type="number"
            label="CategoryId"
            id="CategoryId"
            value={CategoryId}
            onChange={(e) => setCategoryId(e.target.value)}
          />
          <br />
          <TextField
            type="number"
            label="Rate"
            id="Rate"
            value={Rate}
            onChange={(e) => setRate(e.target.value)}
          />
          <br />
          <Button
            onClick={addNewMovie}
            id="add_btn"
            variant="contained"
            size="large"
            color="primary"
            className={classes.margin}
          >
            ADD
          </Button>
        </div>
      </form>
    </div>
    )
}
export default AddMovie