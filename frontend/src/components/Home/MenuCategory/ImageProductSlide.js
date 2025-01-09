import React, { useEffect, useState } from 'react';
import axios from 'axios';
import baseURL from '../../../api/BaseUrl';


function ImageProductSlide({ id, name }) {
    const [images, setImages] = useState([]);


    useEffect(() => {
        // Gọi API để lấy danh sách hình ảnh khi component được render
        axios.get(baseURL + `Gallery/by-product/` + id)
            .then(response => {

                setImages(response.data);
            })
            .catch(error => {
                console.error('Error fetching images:', error);
            });
    }, [id]);

    // Kiểm tra xem images có dữ liệu không trước khi truy cập images.image
    if (!images || images.length === 0) {
        return <img src={require("../../../assets/images/No_Image-1024.png")} width={75} height={75} alt="No_Image-1024" className="showcase-img product-img" />;
    }

    return (
        <div>
            {/* Render img khi images đã được thiết lập */}
            <img src={`data:image/jpg;base64,${images[0].image}`} alt={name} width={75} height={75} className="showcase-img product-img" />


        </div>
    );
}

export default ImageProductSlide;
