import React, { useState } from 'react';
import axios from 'axios';
import { Category } from './types';

const AddCategory: React.FC = () => {
    const [id, setId] = useState();
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    const handleAddCategory = () => {
        const newCategory: Category = { id, name, description };

        axios.post('https://localhost:7006/api/Category/Create', newCategory)
            .then((response: any) => {
                console.log('Category added', response.data);
                alert("Added")
            })
            .catch((error: any) => {
                console.error('There was an error!', error);
                alert("Error")
            });
    };

    return (
        <form>
            {
                <div>
                    <h2>Add Category</h2>
                    <input type="text" value={id} onChange={(e) => setId(e.target.value)} placeholder="Category id" />
                    <input type="text" value={name} onChange={(e) => setName(e.target.value)} placeholder="Category name" />
                    <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Category description" />
                    <button onClick={handleAddCategory}>Add</button>
                </div>
            }
        </form>
    );
};

export default AddCategory;
