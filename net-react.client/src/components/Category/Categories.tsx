import { useEffect, useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from '../../helpers/DotNetApi';
import { Category } from '../../types';
import '../../../src/styles/body.css';
import '../Header';
import { Link } from 'react-router-dom';
import { CategoryImage } from '../../helpers/ImageFolder';


const CategoryList: FC = () => {
    const [categories, setCategories] = useState<Category[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const fetchCategories = async () => {
        try {
            const response = await axios.get<Category[]>(DotNetApi + 'Category');
            setCategories(response.data);
        } catch (error) {
            console.error('There was an error!', error);
        } finally {
            setLoading(false);
        }
    };
    useEffect(() => {
        fetchCategories();
    }, []);

    const tableCategories =
        <div className="row rounded w-75 m-auto">
            {categories.length > 0 ?
                categories.map((category) =>
                    <div className="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 mt-3" key={category.id}>
                        <Link to={`/products/${category.id}`} >
                            <img src={CategoryImage + category.image} className="w-100" />
                        </Link>
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

export default CategoryList;