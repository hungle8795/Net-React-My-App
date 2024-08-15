import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { DotNetApi } from './helpers/DotNetApi';
//import { Category } from './types';

export interface Category {
    id: number;
    name: string;
    description: string;
}

const CategoryList: React.FC = () => {
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        axios.get<Category[]>(DotNetApi + 'Category')
            .then(respose => {
                setCategories(respose.data);
            })
            .catch(
                error => {
                    console.error('There was an error!', error);
                }
            );
    }, []);

    const tableCategories = 
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Desciption</th>
                </tr>
            </thead>
            <tbody>
                {categories.map(category => 
                    <tr key={category.id}> 
                        <td>{category.id}</td>
                        <td>{category.name}</td>
                        <td>{category.description}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1>Categories</h1>
            {tableCategories}
        </div>
    );
}

export default CategoryList;