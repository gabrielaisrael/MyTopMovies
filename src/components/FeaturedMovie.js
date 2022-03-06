import React, {useState} from 'react';
import './FeaturedMovie.css';

export default () => {

    let genres = [];

    const [data, setData]= useState([]);
    const [category, setCategory] = useState('');


    return (
        <section className="featured" style={{
            backgroundSize: 'cover',
            backgroundPosition: 'center',
          
        }}>
            <div className="featured--vertical">
                <div className="featured--horizontal">
                    <div className="featured--name">title</div>
                    <div className="featured--info">
                        <div className="featured--points">rate</div>
                    </div>
                    <div className="featured--genres"><strong>Genre:</strong> </div>
                </div>
            </div>
        </section>
    );
}