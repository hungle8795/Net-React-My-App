import { useState, FC } from "react";
import axios from 'axios';
import { Category } from "./types";
import { DotNetApi } from './helpers/DotNetApi';

const UpdateCategory: FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    /*const handleUpdateCategory = () => {*/
    const handleUpdateCategory = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        if (name.trim() === '') {
            alert("Name are required");
            return;
        }
        const updateCategory: Category = { id, name, description };
        try {
            const response = await axios.put(DotNetApi + `Category/Update/${id}`, updateCategory);
            /*.then(response => {*/
            console.log(response.data);
            alert("Updated!");
            location.reload();
        }
        catch (error) {
            console.log(error);
            alert("Error!");
        }
    };

    return (
        <div className="container">
            <form onSubmit={handleUpdateCategory}>
                <div>
                    <h2>Update Category</h2>
                    <input type="text" value={id !== undefined ? id.toString() : ''} onChange={(e) => setId(e.target.value !== '' ? parseInt(e.target.value) : undefined)} placeholder="Category id"></input>
                    <input type="text" value={name} onChange={(e) => setName(e.target.value)} placeholder="Category name"></input>
                    <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Category description"></input>
                    <button type="submit">Update Category</button>
                </div>
            </form>
        </div>
    );
};

export default UpdateCategory;