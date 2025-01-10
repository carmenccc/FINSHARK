import React from "react";
import { testIncomeStatementData } from "./testData";

const data = testIncomeStatementData;

type Props = {
  config: any;
  data: any;
};

// Render table based on configs
const Table = ({ config, data }: Props) => {
  const renderedHeaders = config.map((config: any) => {
    return (
      <th
        className="p-4 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
        key={config.label}
      >
        {config.label}
      </th>
    );
  });

  const renderedRows = data.map((row: any) => {
    return (
      <tr key={row.cik}>
        {config.map((val: any) => {
          return <td className="p-3">{val.render(row)}</td>;
        })}
      </tr>
    );
  });

  return (
    <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
      <table className="min-w-full divide-y divide-gray-200 m-5">
        <thead className="bg-gray-50">{renderedHeaders}</thead>
        <tbody>{renderedRows}</tbody>
      </table>
    </div>
  );
};

export default Table;
