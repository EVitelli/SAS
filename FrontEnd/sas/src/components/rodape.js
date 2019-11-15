import React from 'react'
import Typography from "@material-ui/core/Typography";

export default function Rodape() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {"Copyright © "}
        SAS
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}