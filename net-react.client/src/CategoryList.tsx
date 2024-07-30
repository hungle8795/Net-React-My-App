import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Category } from './types';

const CategoryList: React.FC = () => {
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        axios.get<Category[]>('https://localhost:7006/api/Category')
            .then(respose => {
                setCategories(respose.data);
            })
            .catch(
                error => {
                    console.error('There was an error!', error);
            }
            );
    }, []);

    return (
        <div>
            <h1>Categories</h1>
            <ul>
                {categories.map((category) => (
                    <li key={category.id}>
                        <h2>{category.id}</h2>
                        <h2>{category.name}</h2>
                        <h2>{category.description}</h2>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default CategoryList;