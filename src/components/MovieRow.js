import React, { useState, useEffect } from 'react'
import { TextField } from '@material-ui/core';
import NavigateBeforeIcon from '@material-ui/icons/NavigateBefore';
import NavigateNextIcon from '@material-ui/icons/NavigateBefore';
import "./MovieRow.css";
import AddMovie from './AddMovie';
import AddCircleIcon from "@material-ui/icons/AddCircle";
import axios from 'axios';


function MovieRow () {

        const [data, setData]= useState([]);
        const [scrollX, setScrollX] = useState(0);
        const [isOpen, setIsOpen] = useState(false);
        const [category, setCategory] = useState('');
        const [value, setValue] = useState(0);

       // const [categoriesOption, setCategoriesOption] = useState<categorieOption[]>([]);


        useEffect(()=> {
           const GetData = () => {
               axios.get('https://localhost:44374/api/Movies/ReadMovie')
               .then((result)=>{
                    console.log(result.data.readMovieData)    
                   setData(result.data.readMovieData)

               })
           } 
           GetData();
        }, [])

        
        const handleLeftArrow = () => {
        
        }
    
        const handleRightArrow = () => {
           
        }
        function openModal() {
            setIsOpen(true);
          }
    
     {
        return (
            
            <div className="movieRow">
                  <div className="movieRow--left" onClick={handleLeftArrow}>
                <NavigateBeforeIcon style={{fontSize: 50}} />
            </div>
            <div className="movieRow--right" onClick={handleRightArrow}>
                <NavigateNextIcon style={{fontSize: 50}} />
            </div>
             {data && data.map((item, key) => {
          return <div key={key} className="movieRow--item">
          <img src={item.imgUrl} alt={item.title} />
      </div>
           
        })}
        <div className="movieRow--listarea">
                <div className="movieRow--list" style={{
                    marginLeft: scrollX,
                    width: data.length * 150
                }}>
                    

                </div>
            </div>


                <div>           <AddCircleIcon
        onClick={openModal}
        fontSize="large"
        className="addMovie_btn"
      />

      {isOpen ? (
        <AddMovie
          setIsOpen={setIsOpen}
        />
      ) : null}</div>
            </div>

        
        
        )
    }
}

export default MovieRow;