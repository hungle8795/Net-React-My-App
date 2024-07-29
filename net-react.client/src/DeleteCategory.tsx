import React, { useState } from 'react';
import axios from 'axios';

const DeleteCategory: React.FC = () => {
    const [id, setId] = useState('');

    const handleDeleteCategory = () => {
        axios.delete(`https://localhost:5001/api/categories/${id}`)
            .then(response => {
                console.log('Category deleted');
            })
            .catch(error => {
                console.error('There was an error!', error);
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
