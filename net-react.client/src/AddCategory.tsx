import React, { useState } from 'react';
import axios from 'axios';
import { Category } from './types';

const AddCategory: React.FC = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    const handleAddCategory = () => {
        const newCategory: Omit<Category, 'id'> = { name, description };

        axios.post('https://localhost:7006/api/categories', newCategory)
            .then(response => {
                console.log('Category added', response.data);
            })
            .catch(error => {
                console.error('There was an error!', error);
            });
    };

    return (
        <div>
            <h2>Add Category</h2>
            <input
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Category name"
            />
            <input
                type="text"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                placeholder="Category description"
            />
            <button onClick={handleAddCategory}>Add</button>
        </div>
    );
};

export default AddCategory;
