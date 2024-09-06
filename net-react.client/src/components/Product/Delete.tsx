import axios from "axios";
import React, { FC, useState } from "react";
import { DotNetApi } from "../../helpers/DotNetApi";

interface DeleteProductProps {
    onDeleteProduct: () => void;
}
const DeleteProduct: FC<DeleteProductProps> = ({ onDeleteProduct }) => {
    const [id, setId] = useState<number | undefined>(undefined);
    const [loading, setLoading] = useState<boolean>(false);
    const handleDeleteProduct = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (id === undefined) {
            alert("Product ID is required.");
            return;
        }
        try {
            setLoading(true);
            const response = await axios.delete(DotNetApi + `product/delete/${id}`);
            console.log('Product deleted: ', response.data);
            alert("Deleted. Reload page");
            onDeleteProduct();
            location.reload();
        }
        catch (error) {
            console.error('There was an error!', error);
            alert("Id not found!");
        }
        finally {
            setLoading(true);
        }
            //.then(response => {
            //    console.log('Product deleted: ', response.data);
            //    alert("Deleted. Reload page");
            //    location.reload();
            //})
            //.catch(error => {
            //    console.error('There was an error!', error);
            //    alert("Id not found!");
            //});
    };
    return (
        <div className="container">
            <form onSubmit={handleDeleteProduct}>
                <div>
                    <h2>Delete Product</h2>
                    <input
                        type="text"
                        value={id}
                        onChange={(e) => setId(e.target.value !== '' ? parseInt(e.target.value) : undefined)}
                        placeholder="Product ID"
                    />
                    <button type="submit" className="btn btn-primary" disabled={loading}>
                        {loading ? 'Deleting...' : 'Delete Product'}
                    </button>
                </div>
            </form>
        </div>
    );
};

export default DeleteProduct;