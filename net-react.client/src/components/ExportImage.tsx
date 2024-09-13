import { useEffect, useState } from 'react';
import axios from 'axios';
import { DotNetApi } from '../helpers/DotNetApi';
const ImageDisplay = () => {
    const [images, setImages] = useState<string[]>([]);
    useEffect(() => {
        const fetchImages = async () => {
            try {
                const response = await axios.get(DotNetApi + "images/upload");
                setImages(response.data);
            }
            catch (error) {
                console.error("Error fetching images: ", error);
            }
        };
        fetchImages();
    }, []);
    return (
        <div>
            {images.map((image, index) => (
                <img key={index} src={image} alt={`Upload ${index}`}></img>
            ))}
        </div>
    );
};
export default ImageDisplay;