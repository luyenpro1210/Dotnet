import { makeStyles } from "@mui/styles";
import React, { useEffect, useState } from "react";
import { GET_TAG_ID, PUT_EDIT_TAG } from "../../api/apiService";
import { Navigate, useParams } from "react-router-dom";
import { Button, Grid, Paper, TextField, Typography } from "@mui/material";
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
export default function EditTag({ match, location }) {
  const classes = useStyles();
  const { id } = useParams();
  const [checkUpdate, setCheckUpdate] = useState(false);
  const [idTag, setIdTag] = useState(0);
  const [name, setName] = useState(null);
  const [icon, setIcon] = useState(null);
  useEffect(() => {
    GET_TAG_ID(`Tag`, id).then((tag) => {
      console.log(tag);
      setIdTag(tag.data.id);
      setName(tag.data.tag_name);
      setIcon(tag.data.icon);
    });
  }, []);
  const handleChangeName = (e) => {
    setName(e.target.value);
  };
  const handleChangeIcon = (e) => {
    setIcon(e.target.value);
  };
  const editProduct = (e) => {
    e.preventDefault();
    if (name !== "" && icon !== "") {
      let tag = {
        tag_name: name,
        icon
      };
      PUT_EDIT_TAG(`Tag/${idTag}`, tag).then((item) => {
        if (item.data === 1) {
          setCheckUpdate(true);
        }
      });
    } else {
      alert("Bạn chưa nhập đầy đủ thông tin!");
    }
  };

  if (checkUpdate) {
    return <Navigate to="/admin/tags" />;
  }
  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography className={classes.title} variant="h4">
              Edit Tag
            </Typography>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Tag Name
                </Typography>
                <TextField
                  id="Name"
                  onChange={handleChangeName}
                  name="Name"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={name}
                />
              </Grid>
              <Grid item xs={12}>
                <Typography gutterBottom variant="subtitle1">
                  Icon
                </Typography>
                <TextField
                  id="Icon"
                  onChange={handleChangeIcon}
                  name="Icon"
                  variant="outlined"
                  className={classes.txtInput}
                  size="small"
                  value={icon}
                />
              </Grid>
              
              <Grid item xs={12}>
                <Button
                  type="button"
                  onClick={editProduct}
                  className={classes.submit}
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  Edit tag
                </Button>
              </Grid>
            </Grid>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}
