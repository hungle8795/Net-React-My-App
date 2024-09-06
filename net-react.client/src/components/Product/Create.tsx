import { useState, FC } from 'react';
import axios from 'axios';
import { Product } from '../../types';
import { DotNetApi } from '../../helpers/DotNetApi';


interface AddProductProps {
    onCreateProduct: () => void; // Định nghĩa prop onAdd là một hàm
}

const AddProduct: FC<AddProductProps> = ({ onCreateProduct }) => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [name, setName] = useState<string>('');
    const [price, setPrice] = useState<number | undefined>(undefined);
    const [image, setImage] = useState<string>('');
    const [description, setDescription] = useState<string>('');
    const [quantity, setQuantity] = useState<string>('');
    const [categoryId, setCategoryId] = useState<number | undefined>(undefined);
    const [createdAt, setCreatedAt] = useState<string>(new Date().toLocaleString());
    const [updatedAt, setUpdatedAt] = useState<string>(new Date().toLocaleString());
    const [loading, setLoading] = useState<boolean>(false);


    //const handleAddCategory = () => {
    const handleAddProduct = async (event: React.FormEvent<HTMLFormElement>) => {
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
        if (price === undefined) {
            alert('Price is required');
            return;
        }
        if (categoryId === undefined) {
            alert('CategoryId is required');
            return;
        }
        setDescription("");
        setQuantity("");
        setCreatedAt("");
        setUpdatedAt("");
        const newProduct: Product = { id, name, description, price, quantity, categoryId, createdAt, updatedAt, image};
        try {
            setLoading(true);
            const response = await axios.post(DotNetApi + 'product/create', newProduct);
            console.log(response.data);
            alert("Product created successfully!");
            onCreateProduct();
            setId(undefined);
            setName('');
            setPrice(undefined);
            setImage('');
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
                        value={id !== undefined ? id.toString() : ''}
                        onChange={(e) => setId(e.target.value !== undefined ? parseInt(e.target.value) : undefined)}
                        placeholder="Product's id"
                    />
                    <input
                        type="text"
                        value={name !== '' ? name : ''}
                        onChange={(e) => setName(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's name"
                    />
                    <input
                        type="text"
                        value={image !== '' ? image : ''}
                        onChange={(e) => setImage(e.target.value !== '' ? e.target.value : '')}
                        placeholder="Product's image"
                    />
                    <input
                        type="text"
                        value={price !== undefined ? price.toString() : ''}
                        onChange={(e) => setPrice(e.target.value !== undefined ? parseInt(e.target.value) : undefined)}
                        placeholder="Product's price"
                    />
                    <input
                        type="text"
                        value={price !== undefined ? price.toString() : ''}
                        onChange={(e) => setCategoryId(e.target.value !== undefined ? parseInt(e.target.value) : undefined)}
                        placeholder="CategoryId"
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


