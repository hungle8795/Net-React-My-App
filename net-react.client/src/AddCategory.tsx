import React, { useState } from 'react';
import axios from 'axios';
import { Category } from './types';

const AddCategory: React.FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    //const handleAddCategory = () => {
    const handleAddCategory = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        const newCategory: Category = { id, name, description };

        axios.post('https://localhost:7006/api/Category/Create', newCategory)
            .then(response => {
                console.log('Category added', response.data);
                alert("Created");
            })
            .catch(error => {
                console.error('There was an error!', error);
                alert("Record is exist!");
            });
    };

    return (
        <div>
            <form>
                <h2>Add Category</h2>
                <input
                    type="text"
                    value={id !== undefined ? id.toString() : ''}
                    onChange={(e) => setId(e.target.value !== undefined ? parseInt(e.target.value) : undefined)}
                    placeholder="Category id"
                />
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
            </form>
        </div>
    );
};

export default AddCategory;
