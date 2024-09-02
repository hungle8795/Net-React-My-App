// import { Category } from './category';
export interface IAddNewProductDto {
  name: string;
  image: string;
  color: string;
  description: string;
  price: number;
  quality: number;
}

export interface Product {
  id: number;
  createdAt: string;
  userName: string;
  name: string;
  description: string;
  color: string;
  price: number;
  quality: number;
  categoryName: string;
  image: string;
}
 export interface SearchResultsProps {
   filteredProducts: Product[];
   searchTerm: string;
   onItemClick: () => void;
   showSearchResults: boolean;
 }

export interface ProductCardProps {
  product: {
    id: number;
    image: string;
    categoryName: string;
    createdAt: string;
    userName: string;
    name: string;
    description: string;
    color: string;
    price: number;
    quality: number;
  };
}
