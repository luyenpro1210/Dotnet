import React, { useEffect, useState } from 'react'
import dress from '../../../assets/images/icons/dress.svg';
import shoes from '../../../assets/images/icons/shoes.svg';
import jewelry from '../../../assets/images/icons/jewelry.svg';
import perfume from '../../../assets/images/icons/perfume.svg';
import cosmetics from '../../../assets/images/icons/cosmetics.svg';
import glasses from '../../../assets/images/icons/glasses.svg';
import bag from '../../../assets/images/icons/bag.svg';
import SidebarMenuCategory from './SidebarMenuCategory';
import axios from 'axios';

import ImageProductSlide from './ImageProductSlide';
import baseURL from '../../../api/BaseUrl';
import { IonIcon } from '@ionic/react';
import { closeOutline, star } from 'ionicons/icons';
function MenuCategoryProductV() {
    const [menuData, setMenuData] = useState([]);
    const [best, setBest] = useState([])
    useEffect(() => {

        axios.get(baseURL + `Categories/Active`)
            .then(response => {

                setMenuData(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
        axios.get(baseURL + `Product/Tag/` + encodeURIComponent("BEST SELLERS"))
            .then(response => {


                setBest(response.data);
            })
            .catch(error => {
                console.error('Error fetching categories:', error);
            });
    }, []);
    console.log(best)
    return (
        <div className="sidebar  has-scrollbar" data-mobile-menu>
            <div className="sidebar-category">
                <div className="sidebar-top">
                    <h2 className="sidebar-title">Category</h2>
                    <button className="sidebar-close-btn" data-mobile-menu-close-btn>
                        {/* <ion-icon name="close-outline" /> */}
                        <IonIcon icon={closeOutline} />
                    </button>
                </div>
                <ul className="sidebar-menu-category-list">
                    {menuData.map((menu, index) => (
                        <SidebarMenuCategory key={index} data={menu} />
                    ))}
                </ul>
            </div>

            {best.length > 0 && (
                <div className="product-showcase">
                    <h3 className="showcase-heading">best sellers</h3>
                    <div className="showcase-wrapper">
                        <div className="showcase-container">
                            {best.map((product) => (
                                <div className="showcase" key={product.id}>
                                    <a href="#" className="showcase-img-box">
                                        <ImageProductSlide id={product.id} name={product.productName} />
                                    </a>
                                    <div className="showcase-content">
                                        <a href="#">
                                            <h4 className="showcase-title">{product.productName}</h4>
                                        </a>
                                        <div className="showcase-rating">
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                            <IonIcon icon={star} />
                                        </div>
                                        <div className="price-box">
                                            <del>${product.buyingPrice}.00</del>


                                            <p className="price">${product.salePrice}.00</p>
                                        </div>
                                    </div>
                                </div>
                            ))}


                        </div>
                    </div>
                </div>
            )}


        </div>
    )
}

export default MenuCategoryProductV


