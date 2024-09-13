import axios from "axios";
import { FC, useState, useEffect } from "react";
import { DotNetApi } from "../../helpers/DotNetApi";
import { Category, Product } from "../../types";
import brand1 from '../../../src/assets/Image/brand1.jpg';
import { useParams } from 'react-router-dom';

const Products: FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const { categoryId } = useParams<{ categoryId: string }>();
    const [cates, setCate] = useState<Category | null>(null);
    const fetchCategoryImage = async () => {
        try {
            const link = categoryId !== undefined ? `${DotNetApi}category/id/${categoryId}` : "";
            const response = await axios.get<Category>(link);
            setCate(response.data);
        } catch (error) {
            console.log('There was an error!', error);
        } finally { }
    };
    const fetchProducts = async () => {
        const host = DotNetApi + 'product';
        const link = categoryId !== undefined ? host + '/categoryid/' + parseInt(categoryId, 10) : host;
        axios.get<Product[]>(link)
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
        fetchCategoryImage();
        fetchProducts();
    }, [categoryId]);

    const categoryImage =
        <div className="">
            {cates ?
                <div key={cates.id}>
                    <img src={cates.image} alt={cates.image} width="100%"></img>
                </div>
                : (
                    <div>
                        <p>No image found.</p>
                    </div>
                )}
        </div>

    const tableProducts =
        <div className="row rounded w-75 m-auto">
            {products.length > 0 ?
                products.map(product =>
                    <div className="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 mt-3" key={product.id}>
                        <div className="border border-dark text-center w-90 my-3 mx-auto rounded">
                            <img src={brand1} className="w-100" />
                            <h5 className="pt-3">{product.name}</h5>
                            <h5 className="pt-3">{product.price}$</h5>
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
            {categoryImage}
            {tableProducts}
        </div>
    )
}

export default Products;
