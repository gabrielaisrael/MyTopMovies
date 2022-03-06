import React, {useState, useEffect} from 'react';
import './Categories.css'
import axios from 'axios'

function Categories () {


    const [ data, setData ] = useState([])

    
    useEffect(()=> {
        const GetData = () => {
            axios.get('https://localhost:44374/api/Movies/ReadCategory')
            .then((result)=>{
                 console.log(result.data.readCategoryData)    
                setData(result.data.readCategoryData)

            })
        } 
        GetData();
     }, [])
    

    return (
        <div className='categories-list'>

{data && data.map((item, key) => {
          return <div key={key}>
                <div className='categories--item'>
              <h2>{item.Title}</h2>  
        </div>
            </div>
            })}
        </div>
    )

}
export default Categories;