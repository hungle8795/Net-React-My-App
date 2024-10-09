//import React, { useState, useEffect } from 'react';
//import { ProductCard } from '../components/ProductCard';
//import { Product } from '../types';

//const ProductPage: React.FC = () => {
//    const [products, setProducts] = useState<Product[]>([]);

//    useEffect(() => {
//        // Giả lập gọi API để lấy dữ liệu sản phẩm
//        fetchProducts();
//    }, []);

//    const fetchProducts = async () => {
//        try {
//            const response = await fetch('/api/products');
//            const data = await response.json();
//            setProducts(data);
//        } catch (error) {
//            console.error('Error fetching products:', error);
//        }
//    };

//    return (
//        <div>
//            <h1>Products</h1>
//            <div className="product-list">
//                {products.map(product => (
//                    <ProductCard key={product.id} {...product} />
//                ))}
//            </div>
//        </div>
//    );
//};

//export default ProductPage;
