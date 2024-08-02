import React, { useState } from "react";
import axios from 'axios';
import { Category } from "./types";

const updateCategory: React.FC = () => {
    const [id, setId] = useState();
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    const handleUpdateCategory = () => {
        const updateCategory: Category = { id, name, description };
        axios.put(`https://localhost:7006/api/Category/Update/${id}`, updateCategory)
            //.then((response: Response) => response.json())
            .then((response: any) => {
                console.log(response.data);
                alert("Updated!");
            })
            .catch((error: any) => {
                console.log(error);
                alert("Error!");
            })
    };

    return (
        <form>
            {
                <div>
                    <h2>Update Category</h2>
                    <input type="text" value={id} onChange={(e) => setId(e.target.value)} placeholder="Category id"></input>
                    <input type="text" value={name} onChange={(e) => setName(e.target.value)} placeholder="Category name"></input>
                    <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Category description"></input>
                    <button onClick={handleUpdateCategory}>Update Category</button>
                </div>
            }
        </form>
    );
};

export default updateCategory;