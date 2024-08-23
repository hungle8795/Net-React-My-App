import { useEffect, useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from './helpers/DotNetApi';
import { Category } from './types';
import ballImg from '../src/assets/Image/ball.jpg';
import '../src/styles/category.css';
import '../src/components/Header';

//export interface Category {
//    id: number;
//    name: string;
//    description: string;
//}

const CategoryList: FC = () => {
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
                }
            );
    };
    useEffect(() => {
        fetchCategories();
    }, []);

    const tableCategories =
        <div className="row border border-dark rounded w-75 m-auto">
            {categories.length > 0 ?
                categories.map(category =>
                    <div className="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3" key={category.id}>
                        <div className="border border-dark text-center w-90 my-3 mx-auto rounded">
                            <img src={ballImg} className="w-100"></img>
                            <h5 className="pt-3">{category.name}</h5>
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
            <div className="m-150px-0 fs-4">
                <p>
                    Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ipsum tempora ullam animi cupiditate repudiandae suscipit!
                    Quis atque obcaecati distinctio quam explicabo laudantium ipsa nesciunt ducimus cum ullam. Facere aperiam corporis ex? Ex.</p>
            </div>
            {loading ? <p>Loading...</p> : tableCategories}
        </div>
    );
}

export default CategoryList;