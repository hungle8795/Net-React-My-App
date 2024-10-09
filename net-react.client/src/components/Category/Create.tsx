import { useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from '../../helpers/DotNetApi';


interface AddCategoryProps {
    onCreateCategory: () => void; // Định nghĩa prop onAdd là một hàm
}

const AddCategory: FC<AddCategoryProps> = ({ onCreateCategory }) => {
    const [id, setId] = useState<string | ''>('');
    const [name, setName] = useState<string | "">("");
    const [description, setDescription] = useState<string | "">("");
    const [image, setImage] = useState<File | null>(null);
    const [imagePreview, setImagePreview] = useState<string | null>(null);
    const [loading, setLoading] = useState<boolean>(false);
/*    const [error, setError] = useState<string | null>(null);*/

    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files) {
            const file = event.target.files?.[0];
            setImage(event.target.files[0]);
            setImagePreview(URL.createObjectURL(file)); // Create a preview URL
           /* setError(null);*/
        }
    };
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
        if (!image) {
            alert("Image is required");
            return;
        }
        /*const newCategory: Category = { id, name, description, image };*/
        try {
            const formData = new FormData();
            formData.append('id', id);
            formData.append('name', name);
            formData.append('description', description);
            formData.append('image', image);
            setLoading(true);
            const token = localStorage.getItem('token');
            const response = await axios.post(DotNetApi + 'Category/Create', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                    Authorization: `Bearer ${token}`
                },
            });
            console.log(response.data);
            alert("Category created successfully!");
            onCreateCategory();
            setId('');
            setName('');
            setDescription('');
            setImage(null);
            setImagePreview(null);
        }
        catch (error) {
            console.error('There was an error!', error);
            alert("Failed to add category. Please check if the record already exists.");
        } finally {
            setLoading(false); // End loading
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
                        value={id !== '' ? id : ''}
                        onChange={(e) => setId(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Brand's id"
                    />
                    <input
                        type="text"
                        value={name !== '' ? name : ''}
                        onChange={(e) => setName(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Brand's name"
                    />
                    <div>
                        <div className="mb-3">
                            <input type="file" accept="image/*" onChange={handleImageChange} required />
                        </div>
                        {imagePreview && <img src={imagePreview} alt="Image Preview" className="img-preview mb-3" style={{ height: "200px" }} />}
                    </div>
                    <input
                        type="text"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        placeholder="Brand's description"
                    />
                    <button type="submit" className="btn btn-primary" disabled={loading}>
                        {loading ? 'Adding...' : 'Add Category'}
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddCategory;


