// SidebarSubmenuCategory.js
import React from 'react';

const SidebarSubmenuCategory = ({ data }) => {

  const capitalizeFirstLetter = (str) => {
    return str.charAt(0).toUpperCase() + str.slice(1);
  };
  return (
    <li className="sidebar-submenu-category">
      <a href="#" className="sidebar-submenu-title">
        <p className="product-name">{capitalizeFirstLetter(data.categoryName)}</p>
        {/* <data value={stock} className="stock" title="Available Stock">{stock}</data> */}
      </a>
    </li>
  );
};

export default SidebarSubmenuCategory;
