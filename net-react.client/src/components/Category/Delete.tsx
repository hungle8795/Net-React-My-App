import { useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from '../../helpers/DotNetApi';

const DeleteCategory: FC = () => {
    const [id, setId] = useState<number | undefined>(undefined);

    const handleDeleteCategory = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (id === undefined) {
            alert("Category ID is required");
            return;
        }
        //axios.delete(DotNetApi + 'Category/Delete/' + id)
        axios.delete(DotNetApi + `Category/Delete/${id}`)
            .then(response => {
                console.log('Category deleted: ', response.data);
                alert("Deleted. Reload page");
                location.reload();
            })
            .catch(error => {
                console.error('There was an error!', error);
                alert("Id not found!");
            });
    };

    return (
        <div className="container">
            <form onSubmit={handleDeleteCategory}>
                <div>
                    <h2>Delete Category</h2>
                    <input
                        type="text"
                        value={id}
                        onChange={(e) => setId(e.target.value !== '' ? parseInt(e.target.value) : undefined)}
                        placeholder="Category ID"
                    />
                    <button type="submit">Delete</button>
                </div>
            </form>
        </div>
    );
};

export default DeleteCategory;
