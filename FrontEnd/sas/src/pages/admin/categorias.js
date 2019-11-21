// import React from "react";
// import { useCategorias } from "./categorias.hooks";

// const Categorias = () => {
//   const categorias = useCategorias();

//   return (
//     <ul>
//       {categorias.map(({ nome }) => (
//         <li>{nome}</li>
//       ))}
//     </ul>
//   );
// };

// export default Categorias;

import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import { useCategorias } from "./categorias.hooks";

const useStyles = makeStyles({
  root: {
    width: "100%",
    overflowX: "auto"
  },
  table: {
    minWidth: 650
  }
});

export default function Categorias() {
  const categorias = useCategorias();
  const classes = useStyles();

  return (
    <Paper className={classes.root}>
      <Table className={classes.table} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>#</TableCell>
            <TableCell>Nome</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {categorias.map(row => (
            <TableRow key={row.categoriaId}>
              <TableCell component="th" scope="row">
                {row.categoriaId}
              </TableCell>
              <TableCell>{row.nome}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
}
