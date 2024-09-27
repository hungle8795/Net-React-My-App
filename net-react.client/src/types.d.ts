export interface Category {
    id: number;
    name: string;
    description: string;
    image: string;
}

export interface Product {
    id: number;
    name: string;
    price: number;
    image: string;
    quantity: number;
    categoryId: number;
    //createdAt: Date;
    //updatedAt: Date;
    description: string;
}

export interface IFile {
    url: string,
    name: string,
}

