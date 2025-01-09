import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";

import { Navigate, useParams } from "react-router-dom";
import { Button, Grid, Paper, TextField, Typography } from "@mui/material";
import {
  GET_ALL_CATEGORIES,
  GET_ALL_PRODUCTS,
  POST_ADD_PRODUCT,
  PUT_EDIT_PRODUCT,
} from "../api/apiService";
const useStyles = makeStyles((theme) => {
  const spacing = (value) => `${value * 8}px`; // Define your custom spacing function

  return {
    root: {
      flexGrow: 1,
      marginTop: spacing(2), // Use the custom spacing function
    },
    paper: {
      padding: spacing(2),
      maxWidth: 600,
      margin: "auto",
    },
    title: {
      fontSize: 30,
      textAlign: "center",
    },
    link: {
      padding: spacing(1),
      display: "inline-block",
    },
    txtInput: {
      width: "98%",
      margin: spacing(1),
    },
    submit: {
      margin: `${spacing(3)} 0 ${spacing(2)}`,
    },
  };
});
const currencies = [
  {
    value: "USD",
    label: "$",
  },
  {
    value: "EUR",
    label: "€",
  },
  {
    value: "BTC",
    label: "b",
  },
  {
    value: "JPY",
    label: "y",
  },
];
export default function ProductTagEdit() {
  const classes = useStyles();
  const { ProductId, TagId } = useParams();
  const [checkEdit, setCheckEdit] = useState(false);

  const [tags, setTags] = useState({});

  const [pros, setPros] = useState({});
  const [tag, setTag] = useState(TagId);
  const [pro, setPro] = useState(ProductId);
  console.log("p", ProductId);
  console.log(pro);
  console.log("t", TagId);
  console.log(tag);
  useEffect(() => {
    GET_ALL_CATEGORIES("Tag").then((item) => {
      setTags(item.data);
    });
    GET_ALL_PRODUCTS("Product").then((item) => {
      setPros(item.data);
    });
  }, []);

  const handleChangeCategory = (e) => {
    setTag(e.target.value);
  };
  const handleChangeProduct = (e) => {
    setPro(e.target.value);
  };
  const EditProduct = async (e) => {
    e.preventDefault();

    if (tag != null) {
      let product = {
        tagId: tag,
        productId: pro,
      };
      console.log(product);
      const editedProductTag = await PUT_EDIT_PRODUCT(
        `ProductTag/${TagId}/${ProductId}`,
        product
      );
      console.log(editedProductTag.data);
      if (editedProductTag.status === 204) {
        setCheckEdit(true);
      }
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkEdit) {
    return <Navigate to="/" />;
  }
  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Edit Product
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Choose Tag
                </Typography>
                <TextField
                  id="outlined-select-currency-native"
                  name="tagId"
                  select
                  value={tag}
                  onChange={handleChangeCategory}
                  SelectProps={{
                    native: true,
                  }}
                  helperText="Please select your currency"
                  variant="outlined"
                  className={classes.txtInput}
                >
                  <option value="0">Choose tag</option>
                  {tags.length > 0 &&
                    tags.map((option) => (
                      <option key={option.id} value={option.id}>
                        {option.tagName}
                      </option>
                    ))}
                </TextField>
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Choose Product
                </Typography>
                <TextField
                  id="outlined-select-currency-native"
                  name="productId"
                  select
                  value={pro}
                  onChange={handleChangeProduct}
                  SelectProps={{
                    native: true,
                  }}
                  helperText="Please select your currency"
                  variant="outlined"
                  className={classes.txtInput}
                >
                  <option value="0">Choose Product</option>
                  {pros.length > 0 &&
                    pros.map((option) => (
                      <option key={option.id} value={option.id}>
                        {option.productName}
                      </option>
                    ))}
                </TextField>
              </Grid>
              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={EditProduct}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="inherit"
                >
                  Edit product
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
