import React, { useState, FC } from 'react';
import axios from 'axios';
import { DotNetApi } from '../../helpers/DotNetApi';


interface AddProductProps {
    onCreateProduct: () => void; // Định nghĩa prop onAdd là một hàm
}

const AddProduct: FC<AddProductProps> = ({ onCreateProduct }) => {
    const [id, setId] = useState<string | ''>('');
    const [name, setName] = useState<string>('');
    const [image, setImage] = useState<File | null>(null);
    const [imagePreview, setImagePreview] = useState<string | null>(null);
    const [price, setPrice] = useState<string | ''>('');
    const [description, setDescription] = useState<string>('');
    const [quantity, setQuantity] = useState<string | ''>('');
    const [categoryId, setCategoryId] = useState<string | ''>('');
    const [loading, setLoading] = useState<boolean>(false);

    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files) {
            const file = event.target.files?.[0];
            setImage(event.target.files[0]);
            setImagePreview(URL.createObjectURL(file));
        }
    }
    //const handleAddCategory = () => {
    const handleAddProduct = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (id === '') {
            alert("Category ID is required");
            return;
        }
        if (name === '') {
            alert("Name is required");
            return;
        }
        if (!image) {
            alert('Image is required');
            return;
        }
        if (price === '') {
            alert('Price is required');
            return;
        }
        if (quantity === '') {
            alert('Quantity is required');
            return;
        }
        if (categoryId === '') {
            alert('CategoryId is required');
            return;
        }
        if (description === "") {
            alert('Description is required');
            return;
        }
        try {
            const formData = new FormData();
            formData.append('id', id);
            formData.append('name', name);
            formData.append('image', image);
            formData.append('price', price);
            formData.append('quantity', quantity);
            formData.append('categoryId', categoryId);
            formData.append('description', description);
            setLoading(true);
            const token = localStorage.getItem('token');
            const response = await axios.post(DotNetApi + 'Product/Create', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                    Authorization: `Bearer ${token}`
                },
            });
            console.log(response.data);
            alert("Product created successfully!");
            onCreateProduct();
            setId('');
            setName('');
            setImage(null);
            setPrice('');
            setCategoryId('');
            setQuantity('');
            setDescription("");
            setImage(null);
        }
        catch (error) {
            console.error('There was an error!', error);
            alert("Failed to add product. Please check if the record already exists.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="container">
            <form onSubmit={handleAddProduct}>
                <div>
                    <h2>Add Product</h2>
                    <input
                        type="text"
                        value={id !== '' ? id : ''}
                        onChange={(e) => setId(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's id"
                    />
                    <input
                        type="text"
                        value={name !== '' ? name : ''}
                        onChange={(e) => setName(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's name"
                    />
                    {/*<input*/}
                    {/*    type="text"*/}
                    {/*    value={image !== '' ? image : ''}*/}
                    {/*    onChange={(e) => setImage(e.target.value !== '' ? e.target.value : '')}*/}
                    {/*    placeholder="Product's image"*/}
                    {/*/>*/}
                    <div>
                        <div className="mb-3">
                            <input type="file" accept="image/*" onChange={handleImageChange} required />
                        </div>
                        {imagePreview && <img src={imagePreview} alt="Image Preview" className="img-preview mb-3" style={{ height: "200px" }} />}
                    </div>
                    <input
                        type="text"
                        value={price !== '' ? price : ''}
                        onChange={(e) => setPrice(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's price"
                    />
                    <input
                        type="text"
                        value={quantity !== '' ? quantity : ''}
                        onChange={(e) => setQuantity(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's quantity"
                    />
                    <input
                        type="text"
                        value={categoryId !== '' ? categoryId : ''}
                        onChange={(e) => setCategoryId(e.target.value !== '' ? e.target.value : '')}
                        placeholder="CategoryId"
                    />
                    <input
                        type="text"
                        value={description !== '' ? description : ''}
                        onChange={(e) => setDescription(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Description"
                    />
                    <button type="submit" className="btn btn-primary" disabled={loading}>
                        {loading ? 'Adding...' : 'Add Product'}
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddProduct;


