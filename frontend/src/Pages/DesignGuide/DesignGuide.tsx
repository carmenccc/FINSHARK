import React from "react";
import Table from "../../Components/Table/Table";
import RatioList from "../../Components/RatioList/RatioList";

type Props = {};

const DesignGuide = (props: Props) => {
  return (
    <>
      <h1>
        Design guide- This is the design guide for Fin Shark. These are reuable
        components of the app with brief instructions on how to use them.
      </h1>
      <h2> RatioList </h2>
      <RatioList />
      <h2>Table</h2>

      <h3>
        Table takes in a configuration object and company data as params. Use
        the config to style your table.
      </h3>
      <Table />
    </>
  );
};

export default DesignGuide;
