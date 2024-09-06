import { useEffect, useState, FC } from 'react';
import axios from 'axios';
import '../styles/body.css';
import '../components/Header';
import brand1 from '../assets/Image/brand1.jpg';
import { DotNetApi } from '../helpers/DotNetApi';
import { Category } from '../types';
//import brand2 from '../src/assets/Image/brand2.jpg';
//import brand3 from '../src/assets/Image/brand3.jpg';
//import brand4 from '../src/assets/Image/brand4.jpg';
//import brand5 from '../src/assets/Image/brand5.jpg';
//import brand6 from '../src/assets/Image/brand6.jpg';
//import brand7 from '../src/assets/Image/brand7.jpg';
//import brand8 from '../src/assets/Image/brand8.jpg';
/*import { Link } from 'react-router-dom';*/


const Home: FC = () => {
    const [categories, setCategories] = useState<Category[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const fetchCategories = async () => {
        axios.get<Category[]>(DotNetApi + 'Category')
            .then(respose => {
                setCategories(respose.data);
                setLoading(false);
            })
            .catch(
                error => {
                    console.error('There was an error!', error);
                    setLoading(false);
                },
            );
    };
    useEffect(() => {
        fetchCategories();
    }, []);

    const tableCategories =
        //<div className="row border border-dark rounded w-75 m-auto">
        <div className="row rounded w-75 m-auto">
            {categories.length > 0 ?
                categories.map(category =>
                    <div className="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 mt-3" key={category.id}>
                        <div className="border border-dark text-center w-90 my-3 mx-auto rounded">
                            <img src={brand1} className="w-100"></img>
                            <h5 className="pt-3">{category.name}</h5>
                            <h5 className="pt-3">{category.image}</h5>
                            <button className="btn btn-outline-primary mb-3">Detail</button>
                        </div>
                    </div>
                ) : (
                    <div>   
                        <p>No categories found.</p>
                    </div>
                )}
        </div>

    return (
        <div className="container">
            {loading ? <p>Loading...</p> : tableCategories}
        </div>
    );
}

export default Home;