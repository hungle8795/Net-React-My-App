import { useState, FC } from 'react';
import axios from 'axios';
import { Category } from './types';
import { DotNetApi } from './helpers/DotNetApi';

const AddCategory: FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState<string | ''>('');
    const [description, setDescription] = useState('');
    const [image, setImage] = useState<string | ''>('');

    //const handleAddCategory = () => {
    const handleAddCategory = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        if (name === '') {
            alert("Name is required");
            return;
        }
        if (image.trim() === '') {
            alert('Image is required');
            return;
        }
        const newCategory: Category = { id, name, description, image };
        try {
            const response = await axios.post(DotNetApi + 'Category/Create', newCategory)
            console.log(response.data);
            alert("Created. Reload page");
            location.reload();
        }
        catch (error) {
            console.error('There was an error!', error);
            alert("Record is exist!");
        }
    };

    //axios.post(DotNetApi + 'Category/Create', newCategory)
    //    .then(response => {
    //        console.log('Category added', response.data);
    //        alert("Created. Reload page");
    //        location.reload();
    //    })
    //    .catch(error => {
    //        console.error('There was an error!', error);
    //        alert("Record is exist!");
    //    });
    //};

    return (
        <div className="container">
            <form onSubmit={handleAddCategory}>
                <div>
                    <h2>Add Category</h2>
                    <input
                        type="text"
                        value={id !== undefined ? id.toString() : ''}
                        onChange={(e) => setId(e.target.value !== undefined ? parseInt(e.target.value) : undefined)}
                        placeholder="Brand's id"
                    />
                    <input
                        type="text"
                        value={name !== '' ? name : ''}
                        onChange={(e) => setName(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Brand's name"
                    />
                    <input
                        type="text"
                        value={image !== '' ? image : ''}
                        onChange={(e) => setImage(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Brand's image"
                    />
                    <input
                        type="text"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        placeholder="Brand's description"
                    />
                    <button type="submit">Add</button>
                </div>
            </form>
        </div>
    );
};

export default AddCategory;
