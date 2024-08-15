import React, { useState } from "react";
import axios from 'axios';
import { Category } from "./types";
import { DotNetApi } from './helpers/DotNetApi';

const updateCategory: React.FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    /*const handleUpdateCategory = () => {*/
    const handleUpdateCategory = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        const updateCategory: Category = { id, name, description };
        axios.put(DotNetApi + `Category/Update/${id}`, updateCategory)
            //.then((response: Response) => response.json())
            .then(response => {
                console.log(response.data);
                alert("Updated!");
            })
            .catch(error => {
                console.log(error);
                alert("Error!");
            })
    };

    return (
        <form>
            {
                <div>
                    <h2>Update Category</h2>
                    <input type="text" value={id !== undefined ? id.toString() : ''} onChange={(e) => setId(e.target.value !== '' ? parseInt(e.target.value) : undefined)} placeholder="Category id"></input>
                    <input type="text" value={name} onChange={(e) => setName(e.target.value)} placeholder="Category name"></input>
                    <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Category description"></input>
                    <button onClick={handleUpdateCategory}>Update Category</button>
                </div>
            }
        </form>
    );
};

export default updateCategory;