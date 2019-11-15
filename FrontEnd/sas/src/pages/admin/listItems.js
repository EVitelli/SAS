import React from "react";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import DashboardIcon from "@material-ui/icons/Dashboard";
import CalendarToday from "@material-ui/icons/CalendarToday";
import PeopleIcon from "@material-ui/icons/People";
import BarChartIcon from "@material-ui/icons/BarChart";
import DoneAll from "@material-ui/icons/DoneAll";
import ListSubheader from "@material-ui/core/ListSubheader";
import AssignmentIcon from "@material-ui/icons/Assignment";
import { Link } from "react-router-dom";

export const mainListItems = (
  <div>
    <ListItem button component={Link} to={'dashboard'}>
      <ListItemIcon>
        <DashboardIcon />
      </ListItemIcon>
      <ListItemText primary="Dashboard" />
    </ListItem>
    <ListItem button component={Link} to={`dashboard/agendamentos`}>
      <ListItemIcon>
        <CalendarToday />
      </ListItemIcon>
      <ListItemText primary="Agendamentos" />
    </ListItem>
    <ListItem button component={Link} to={`dashboard/ambientes`}>
      <ListItemIcon>
        <DoneAll />
      </ListItemIcon>
      <ListItemText primary="Ambientes" />
    </ListItem>
    <ListItem button component={Link} to={`dashboard/categorias`}>
      <ListItemIcon>
        <BarChartIcon />
      </ListItemIcon>
      <ListItemText primary="Categorias" />
    </ListItem>
    <ListItem button component={Link} to={`dashboard/participantes`}>
      <ListItemIcon>
        <PeopleIcon />
      </ListItemIcon>
      <ListItemText primary="Participantes" />
    </ListItem>
  </div>
);

export const secondaryListItems = (
  <div>
    <ListSubheader inset>Administração</ListSubheader>
    <ListItem button>
      <ListItemIcon>
        <AssignmentIcon />
      </ListItemIcon>
      <ListItemText primary="Usuários" />
    </ListItem>
  </div>
);
