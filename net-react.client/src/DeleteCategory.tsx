import React, { useState } from 'react';
import axios from 'axios';
import { DotNetApi } from './helpers/DotNetApi';

const DeleteCategory: React.FC = () => {
    const [id, setId] = useState('');

    const handleDeleteCategory = () => {
        axios.delete(DotNetApi + `Category/Delete/${id}`)
            .then(response => {
                console.log('Category deleted: ', response.data);
                alert("Deleted. Reload page");
            })
            .catch(error => {
                console.error('There was an error!', error);
                alert("Id not found!");
            });
    };

    return (
        <div>
            <h2>Delete Category</h2>
            <input
                type="text"
                value={id}
                onChange={(e) => setId(e.target.value)}
                placeholder="Category ID"
            />
            <button onClick={handleDeleteCategory}>Delete</button>
        </div>
    );
};

export default DeleteCategory;
