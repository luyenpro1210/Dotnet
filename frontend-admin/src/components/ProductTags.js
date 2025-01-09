import React, { useEffect, useState } from "react";
import { makeStyles } from "@mui/styles";
import Paper from "@mui/material/Paper";
import Grid from "@mui/material/Grid";
import Alert from "@mui/material/Alert";
import IconButton from "@mui/material/IconButton";
import CloseIcon from "@mui/icons-material/Close";
import Button from "@mui/material/Button";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import { Link } from "react-router-dom";
import {
  DELETE_PRODUCT_ID,
  GET_ALL_PRODUCTS,
  GET_PRODUCT_TAGS,
  GET_TAG_NAME,
} from "../api/apiService";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginTop: 20,
  },
  paper: {
    width: "100%",
    margin: "auto",
  },
  removeLink: {
    textDecoration: "none",
  },
}));

export default function ProductTags({ tagName }) {
  const classes = useStyles();
  const [products, setProducts] = useState([]);
  const [tagId, setTagId] = useState();
  const [checkDeleteProduct, setCheckDeleteProduct] = useState(false);
  const [close, setClose] = useState(false);

  useEffect(() => {
    GET_PRODUCT_TAGS(`ProductTag`, tagName).then((item) =>
      setProducts(item.data)
    );
    GET_TAG_NAME(`Tag`, tagName).then((item) => setTagId(item.data.id));
  }, [tagName]);
  console.log(tagId);
  //const RawHTML = ({ body, className }) => (
  //    <div
  //        className={className}
  //        dangerouslySetInnerHTML={{ __html: body.replace(/\n/g, "<br />") }}
  //    />
  //);

  const deleteProductID = (productId) => {
    DELETE_PRODUCT_ID(`ProductTag/${tagId}/${productId}`).then((item) => {
      console.log(item);
      if (item.status === 204) {
        setCheckDeleteProduct(true);
        // setProducts(products.filter((key) => key.idProduct !== id));
        GET_PRODUCT_TAGS(`ProductTag`, tagName).then((item) =>
          setProducts(item.data)
        );
      }
    });
  };
  console.log(products);
  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            {checkDeleteProduct && (
              <Alert
                action={
                  <IconButton
                    aria-label="close"
                    color="inherit"
                    size="small"
                    onClick={() => {
                      setClose(true);
                      setCheckDeleteProduct(false);
                    }}
                  >
                    <CloseIcon fontSize="inherit" />
                  </IconButton>
                }
              >
                Delete successfully
              </Alert>
            )}
            <TableContainer component={Paper}>
              <Table className={classes.table} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell style={{ fontWeight: "bold" }} align="center">
                      Product Name
                    </TableCell>
                    <TableCell style={{ fontWeight: "bold" }} align="center">
                      Tag Name
                    </TableCell>

                    <TableCell style={{ fontWeight: "bold" }} align="center">
                      Delete
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {products.length > 0 &&
                    products.map((row) => (
                      <TableRow key={row.idProduct}>
                        {console.log(row)}
                        <TableCell component="th" scope="row" align="center">
                          {row?.product?.productName}
                        </TableCell>
                        <TableCell align="center">
                          {row?.tag?.tagName}
                        </TableCell>

                        <TableCell align="center">
                          <Link
                            to={`/edit/producttags/${row.product.id}/${tagId}`}
                            className={classes.removeLink}
                          >
                            <Button
                              style={{
                                borderRadius: "5px",
                                color: "white",
                                backgroundColor: "black",
                              }}
                            >
                              Edit
                            </Button>
                          </Link>
                        </TableCell>
                        <TableCell align="center">
                          <Button
                            style={{
                              borderRadius: "5px",
                              color: "white",
                              backgroundColor: "black",
                            }}
                            size="small"
                            variant="Contained"
                            color="secondary"
                            onClick={() => deleteProductID(row.product.id)}
                          >
                            Remove
                          </Button>
                        </TableCell>
                      </TableRow>
                    ))}
                </TableBody>
              </Table>
            </TableContainer>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
