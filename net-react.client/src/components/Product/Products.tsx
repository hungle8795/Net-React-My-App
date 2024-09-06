import axios from "axios";
import { FC, useState, useEffect } from "react";
import { DotNetApi } from "../../helpers/DotNetApi";
import { Product } from "../../types";
import brand1 from '../../../src/assets/Image/brand1.jpg';
import { useParams } from 'react-router-dom';

const Products: FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const { categoryId } = useParams<{ categoryId: string }>();
    const fetchProducts = async () => {
        const cateId = categoryId !== undefined ? parseInt(categoryId, 10) : 0;
        axios.get<Product[]>(DotNetApi + 'product/' + cateId)
            .then(response => {
                setProducts(response.data);
            })
            .catch(
                error => {
                    console.error('There was an error!', error);
                },
            );
    };
    useEffect(() => {
        fetchProducts();
    }, [categoryId]);
    const tableProducts =
        <div>
            {products.length > 0 ?
                products.map(product =>
                    <div className="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 mt-3" key={product.id}>
                        <div className="border border-dark text-center w-90 my-3 mx-auto rounded">
                            <img src={brand1} className="w-100" />
                            <h5 className="pt-3">{product.name}</h5>
                            <h5 className="pt-3">{product.price}</h5>
                            <button className="btn btn-outline-primary mb-3">Detail</button>
                        </div>
                    </div>
                ) : (
                    <div>
                        <p>No product found.</p>
                    </div>
                )}
        </div>
    return (
        <div>
            {tableProducts}
        </div>
    )
}

export default Products;
