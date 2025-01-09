// SidebarMenuCategory.js
import React, { useEffect, useState } from 'react';

import SidebarSubmenuCategory from './SidebarSubmenuCategory';
import Axios from 'axios';
import baseURL from '../../../api/BaseUrl';
import { IonIcon } from '@ionic/react';
import { addOutline, removeOutline } from 'ionicons/icons';

const SidebarMenuCategory = ({ data }) => {
  const [isActive, setIsActive] = useState(false);
  const [subCategory, setSubCategory] = useState([]);
  useEffect(() => {
    // Gọi API để lấy danh sách category khi component được render
    Axios.get(baseURL + `Categories/${data.id}/Children`)
      .then(response => {

        setSubCategory(response.data);
      })
      .catch(error => {
        console.error('Error fetching categories:', error);
      });
  }, [data.id]);
  const toggleAccordion = () => {
    setIsActive(!isActive);
  };

  return (
    <li className="sidebar-menu-category">
      <button className={`sidebar-accordion-menu ${isActive ? 'active' : ''}`} onClick={subCategory.length > 0 ? toggleAccordion : undefined} data-accordion-btn>
        <div className="menu-title-flex">
          <img src={`data:image/svg+xml;base64,${data.image}`} alt={data.categoryName} width={20} height={20} className="menu-title-img" />
          <p className="menu-title">{data.categoryName}</p>
        </div>
        <div>
          {isActive ? (
            <IonIcon icon={removeOutline} className="remove-icon" />
          ) : (
            <IonIcon icon={addOutline} className="add-icon" />
          )}
        </div>

      </button>
      <ul className={`sidebar-submenu-category-list ${isActive ? 'active' : ''}`} data-accordion>
        {subCategory.length > 0 && subCategory.map((item, index) => (
          <SidebarSubmenuCategory key={index} data={item} />
        ))}
      </ul>
    </li>
  );
};

export default SidebarMenuCategory;
