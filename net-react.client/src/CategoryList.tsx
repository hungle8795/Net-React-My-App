import /*React,*/ { useEffect, useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from './helpers/DotNetApi';
import { Category } from './types';

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
        //axios.get<Category[]>(DotNetApi + 'Category')
        //    .then(respose => {
        //        setCategories(respose.data);
        //        setLoading(false);
        //    })
        //    .catch(
        //        error => {
        //            console.error('There was an error!', error);
        //            setLoading(false);
        //        }
        //    );
    }, []);
    //const handleRefresh = () => {
    //    fetchCategories(); // Gọi lại hàm để làm mới danh sách
    //};

    const tableCategories =
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                {categories.length > 0 ?
                    categories.map(category =>
                        <tr key={category.id}>
                            <td>{category.id}</td>
                            <td>{category.name}</td>
                            <td>{category.description}</td>
                        </tr>
                    ) : (
                        <tr>
                            <td colSpan={3}>No categories found.</td>
                        </tr>
                    )}
            </tbody>
        </table>;

    return (
        <div className="container">
            <h2>Introduce</h2>
            {loading ? <p>Loading...</p> : tableCategories}
        </div>
    );
}

export default CategoryList;