import React, { useState } from 'react';
import axios from 'axios';
import { Category } from './types';
import { DotNetApi } from './helpers/DotNetApi';

const AddCategory: React.FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState<string | ''>('');
    const [description, setDescription] = useState('');

    const handleAddCategory = () => {
    //const handleAddCategory = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        //event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        if (name === '') {
            alert("Name is null");
            return;
        }
        const newCategory: Category = { id, name, description };

        axios.post(DotNetApi + 'Category/Create', newCategory)
            .then(response => {
                console.log('Category added', response.data);
                alert("Created. Reload page");
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
                    value={name !== '' ? name : ''}
                    onChange={(e) => setName(e.target.value !== '' ? e.target.value : '')}
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
