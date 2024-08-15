import React from 'react';

interface ProductCardProps {
    id: number;
    name: string;
    price: number;
    imageUrl: string;
}

const ProductCard: React.FC<ProductCardProps> = ({ id, name, price, imageUrl }) => {
    return (
        <div className="product-card">
            <img src={imageUrl} alt={name} />
            <h2>{name}</h2>
            <p>${price}</p>
            <button>Add to Cart</button>
        </div>
    );
};

export default ProductCard;