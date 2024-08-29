import { useState, FC } from "react";
import axios from 'axios';
import { Category } from "./types";
import { DotNetApi } from './helpers/DotNetApi';

const UpdateCategory: FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [image, setImage] = useState<string | ''>('');

    /*const handleUpdateCategory = () => {*/
    const handleUpdateCategory = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        if (name.trim() === '') {
            alert("Name is required");
            return;
        }
        if (image.trim() === '') {
            alert('Image is required');
            return;
        }
        const updateCategory: Category = { id, name, image, description };
        try {
            const response = await axios.put(DotNetApi + `Category/Update/${id}`, updateCategory);
            /*.then(response => {*/
            console.log(response.data);
            alert("Updated. Reload page");
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
                    <input
                        type="text"
                        value={id !== undefined ? id.toString() : ''}
                        onChange={(e) => setId(e.target.value !== '' ? parseInt(e.target.value) : undefined)} placeholder="Brand's id"></input>
                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)} placeholder="Brand's name"
                    />
                    <input
                        type="text"
                        value={image}
                        onChange={(e) => setImage(e.target.value)} placeholder="Brand's image"
                    />
                    <input
                        type="text"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)} placeholder="Brand's description"
                    />
                    <button type="submit">Update Category</button>
                </div>
            </form>
        </div>
    );
};

export default UpdateCategory;